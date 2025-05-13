using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
namespace ShopAPI
{
    public partial class Form1 : Form
    {
       
        private static readonly HttpClient httpClientAI = new HttpClient();
        private static readonly HttpClient httpRawg = new HttpClient();
        private static readonly HttpClient httpCheapShark = new HttpClient();

        private const string apiKeyAI = "55B00dpTabCpJEVuuWRWrPFhFscWjlqLZA2TBCBz"; //utilizzo limitato, non sempre funziona
        private const string rawgApiKey = "d028ec64ba76480d90f81848c8a6a155";
        private const string BaseUrlRawg = "https://api.rawg.io/api/";
        private const string BaseUrlCheapShark = "https://www.cheapshark.com/api/1.0/";

        private readonly string _saveFilePath = Path.Combine(
           Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
           "ProgettoAPI",
           "savedGames.json");

        private List<string> _listGiochi = new List<string>();
        public Form1()
        {
            InitializeComponent();

            LoadData();
        }

        private async void b_genera_Click(object sender, EventArgs e)
        {
            try
            {
                b_genera.Enabled = false;
                Cursor = Cursors.WaitCursor;

                var userInput = txt_descrizione.Text;
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    MessageBox.Show("Inserisci una descrizione prima di generare.", "Campo vuoto",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = await MakeApiRequest(userInput);
                txt_risposta.Text = result;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore: {ex.Message}", "Errore",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                b_genera.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private async Task<string> MakeApiRequest(string userPrompt)
        {
            httpClientAI.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKeyAI);

            var payload = new
            {
                model = "command-r-plus",
                prompt = $"Genera una lista di 10 videogiochi senza nient'altro oltre la lista con questa descrizione: {userPrompt}.",
                max_tokens = 300,
                temperature = 0.7,
                k = 0,
                stop_sequences = new string[] { },
                return_likelihoods = "NONE"
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var endpoint = "https://api.cohere.com/v1/generate";

            var response = await httpClientAI.PostAsync(endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                var err = await response.Content.ReadAsStringAsync();
                return $"Errore: {response.StatusCode} - {err}";
            }

            var json = await response.Content.ReadAsStringAsync();
            var doc = JsonDocument.Parse(json);

            try
            {
                var generations = doc.RootElement.GetProperty("generations");
                return generations.GetArrayLength() > 0
                    ? generations[0].GetProperty("text").GetString()?.Trim() ?? "Testo vuoto"
                    : "Errore: nessuna generazione trovata";
            }
            catch (KeyNotFoundException)
            {
                return $"Errore: formato risposta API non valido: {json}";
            }
        }

        private async void b_cerca_Click(object sender, EventArgs e)
        {

            var nome = txt_nomegioco.Text.Trim();
            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Inserisci un nome di gioco.", "Attenzione",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                b_cerca.Enabled = false;
                txt_descrizionegioco.Text = "Caricamento...";

               
                int? gameId = await RawgApiClient.SearchGameIdAsync(httpRawg, rawgApiKey, BaseUrlRawg, nome);
                if (gameId == null)
                {
                    txt_descrizionegioco.Text = "Gioco non trovato.";
                    return;
                }

               
                string descrEn = await RawgApiClient.GetGameDescriptionAsync(httpRawg, rawgApiKey, BaseUrlRawg, gameId.Value);

                txt_descrizionegioco.Text = descrEn;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore: {ex.Message}", "Errore",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_descrizionegioco.Text = string.Empty;
            }
            finally
            {
                b_cerca.Enabled = true;
            }
        }

        private void b_salvagioco_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_nomegioco.Text))
            {
                MessageBox.Show("Inserisci un nome di gioco.", "Attenzione",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nuovoGioco = txt_nomegioco.Text.Trim();

           
            bool esisteGiocoSimile = false;

            foreach (string gioco in _listGiochi)
            {
                if (gioco.Equals(nuovoGioco, StringComparison.OrdinalIgnoreCase))
                {
                    esisteGiocoSimile = true;
                    break;
                }

                
                if (gioco.Contains(nuovoGioco) ||
                    nuovoGioco.Contains(gioco))
                {
                    esisteGiocoSimile = true;
                    break;
                }
            }

            if (esisteGiocoSimile)
            {
                MessageBox.Show("Un gioco con nome uguale o simile è già presente nella lista.",
                               "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

     
            _listGiochi.Add(nuovoGioco);
            cbox_tuoigiochiprezzo.Items.Add(nuovoGioco);
            txt_nomegioco.Clear(); 
        }

        private async void b_cercaprezzi_Click(object sender, EventArgs e)
        {
            string nome = txt_nomegiocoprezzo.Text.Trim();
            if (string.IsNullOrEmpty(nome) && cbox_tuoigiochiprezzo.SelectedIndex == -1)
            {
                MessageBox.Show("Inserisci un nome di gioco.", "Attenzione",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (cbox_tuoigiochiprezzo.SelectedIndex != -1)
            {
                nome = cbox_tuoigiochiprezzo.SelectedItem.ToString();
            }

            try
            {
                b_cercaprezzi.Enabled = false;
                Cursor = Cursors.WaitCursor;

            
                Console.WriteLine($"Cercando prezzi per: {nome}");

             
                var listPrezzi = await GetGameStoresPricesFromCheapSharkAsync(nome);

                if (listPrezzi.Count == 0)
                {
                    MessageBox.Show("Nessun prezzo trovato per questo gioco.", "Informazione",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            
                data_prezzi.DataSource = null;
                data_prezzi.DataSource = listPrezzi;

              
                ConfigureDataGridViewForLinks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore: {ex.Message}", "Errore",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                b_cercaprezzi.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

    
        private void ConfigureDataGridViewForLinks()
        {
           
            if (data_prezzi.DataSource != null)
            {
               
                if (data_prezzi.Columns.Contains("Price"))
                {
                    data_prezzi.Columns["Price"].DefaultCellStyle.Format = "0.00 €";
                    data_prezzi.Columns["Price"].HeaderText = "Prezzo";
                }

                if (data_prezzi.Columns.Contains("RetailPrice"))
                {
                    data_prezzi.Columns["RetailPrice"].DefaultCellStyle.Format = "0.00 €";
                    data_prezzi.Columns["RetailPrice"].HeaderText = "Prezzo originale";
                }

                if (data_prezzi.Columns.Contains("Savings"))
                {
                    data_prezzi.Columns["Savings"].DefaultCellStyle.Format = "0.00 %";
                    data_prezzi.Columns["Savings"].HeaderText = "Sconto";
                }

           
                if (data_prezzi.Columns.Contains("StoreName"))
                {
                    data_prezzi.Columns["StoreName"].HeaderText = "Negozio";
                }

                
                if (data_prezzi.Columns.Contains("DealUrl"))
                {
                    
                    DataGridViewLinkColumn linkColumn = new DataGridViewLinkColumn();
                    linkColumn.DataPropertyName = "DealUrl";
                    linkColumn.HeaderText = "Link all'offerta";
                    linkColumn.Name = "LinkColumn";
                    linkColumn.UseColumnTextForLinkValue = false;
                    linkColumn.Text = "Vai all'offerta";

                   
                    int originalColumnIndex = data_prezzi.Columns["DealUrl"].Index;
                    data_prezzi.Columns.Remove("DealUrl");

                    
                    data_prezzi.Columns.Insert(originalColumnIndex, linkColumn);

                   
                    data_prezzi.CellContentClick -= DataGridView_CellContentClick;
                    data_prezzi.CellContentClick += DataGridView_CellContentClick;
                }
            }
        }

       
        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (data_prezzi.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
                {
                    string url = data_prezzi.Rows[e.RowIndex].Cells["LinkColumn"].Value?.ToString();
                    if (!string.IsNullOrEmpty(url))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(url);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Impossibile aprire il link: {ex.Message}", "Errore",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private async Task<List<StorePrice>> GetGameStoresPricesFromCheapSharkAsync(string gameName)
        {
            try
            {
                
                var result = new List<StorePrice>();

               
                string searchUrl = $"{BaseUrlCheapShark}games?title={Uri.EscapeDataString(gameName)}&limit=10";
                Console.WriteLine($"URL di ricerca: {searchUrl}");

                string searchResponse = await httpCheapShark.GetStringAsync(searchUrl);
                Console.WriteLine($"Risposta della ricerca (primi 200 caratteri): {searchResponse.Substring(0, Math.Min(200, searchResponse.Length))}");

                
                var games = JsonDocument.Parse(searchResponse);
                if (games.RootElement.GetArrayLength() == 0)
                {
                    Console.WriteLine("Nessun gioco trovato nell'API CheapShark");
                    return result;
                }

            
                Console.WriteLine($"Trovati {games.RootElement.GetArrayLength()} giochi corrispondenti:");
                for (int i = 0; i < Math.Min(5, games.RootElement.GetArrayLength()); i++)
                {
                    var gameElement = games.RootElement[i];
                  
                    string gameTitle = "";
                    string gameId = "";
                    string cheapestPrice = "";

                    if (gameElement.TryGetProperty("external", out var externalProp))
                        gameTitle = externalProp.GetString();

                    if (gameElement.TryGetProperty("gameID", out var gameIdProp))
                        gameId = gameIdProp.GetString();

                    if (gameElement.TryGetProperty("cheapest", out var cheapestProp))
                        cheapestPrice = cheapestProp.GetString();

                    Console.WriteLine($"{i + 1}. {gameTitle} (ID: {gameId}, Prezzo più basso: {cheapestPrice})");
                }

                
                string selectedGameId = "";
                string selectedGameTitle = "";

                var firstGame = games.RootElement[0];
                if (firstGame.TryGetProperty("gameID", out var idProp))
                    selectedGameId = idProp.GetString();

                if (firstGame.TryGetProperty("external", out var titleProp))
                    selectedGameTitle = titleProp.GetString();

                Console.WriteLine($"Selezionato gioco: {selectedGameTitle} (ID: {selectedGameId})");
                l_giocoscelto.Text = selectedGameTitle;

                
                string gameDetailsUrl = $"{BaseUrlCheapShark}games?id={selectedGameId}";
                Console.WriteLine($"URL per i dettagli del gioco: {gameDetailsUrl}");

                string gameDetailsResponse = await httpCheapShark.GetStringAsync(gameDetailsUrl);

               
                Console.WriteLine("====== INIZIO RISPOSTA GAME DETAILS COMPLETA ======");
                Console.WriteLine(gameDetailsResponse);
                Console.WriteLine("====== FINE RISPOSTA GAME DETAILS COMPLETA ======");

            
                string storesUrl = $"{BaseUrlCheapShark}stores";
                Console.WriteLine($"URL per gli store: {storesUrl}");

                string storesResponse = await httpCheapShark.GetStringAsync(storesUrl);

              
                var storesDoc = JsonDocument.Parse(storesResponse);
                var storeDict = new Dictionary<string, string>();

                foreach (var storeElement in storesDoc.RootElement.EnumerateArray())
                {
                    if (storeElement.TryGetProperty("storeID", out var storeIdProp) &&
                        storeElement.TryGetProperty("storeName", out var storeNameProp))
                    {
                        string storeId = storeIdProp.GetString();
                        string storeName = storeNameProp.GetString();
                        storeDict[storeId] = storeName;
                    }
                }

                Console.WriteLine($"Dizionario store creato con {storeDict.Count} store");

     
                JObject gameDetails = JObject.Parse(gameDetailsResponse);
                JArray dealsArray = (JArray)gameDetails["deals"];

                Console.WriteLine($"Trovati {dealsArray?.Count ?? 0} deals");

              
                if (dealsArray != null && dealsArray.Count > 0)
                {
                    JObject firstDeal = (JObject)dealsArray[0];
                    Console.WriteLine("Struttura del primo deal:");
                    foreach (var prop in firstDeal.Properties())
                    {
                        Console.WriteLine($"  - {prop.Name}: {prop.Value}");
                    }
                }

              
                if (dealsArray != null)
                {
                    foreach (JObject deal in dealsArray)
                    {
                        try
                        {
                            string storeId = deal["storeID"]?.ToString();
                            string dealId = deal["dealID"]?.ToString(); 

                            
                            string priceStr = deal["price"]?.ToString();
                            string retailPriceStr = deal["retailPrice"]?.ToString();

                            Console.WriteLine($"Deal: StoreID={storeId}, Price={priceStr}, RetailPrice={retailPriceStr}, DealID={dealId}");

                            if (string.IsNullOrEmpty(storeId) || string.IsNullOrEmpty(priceStr))
                            {
                                Console.WriteLine("  Saltato: ID store o prezzo mancante");
                                continue;
                            }

                            
                            decimal price = 0;
                            decimal retailPrice = 0;
                            decimal savings = 0;

                           
                            if (decimal.TryParse(priceStr,
                                              System.Globalization.NumberStyles.Any,
                                              System.Globalization.CultureInfo.InvariantCulture,
                                              out price))
                            {
                                Console.WriteLine($"  Prezzo convertito: {price}");
                            }
                            else
                            {
                                Console.WriteLine($"  Impossibile convertire il prezzo '{priceStr}'");
                                continue;
                            }

                            
                            if (!string.IsNullOrEmpty(retailPriceStr) &&
                                decimal.TryParse(retailPriceStr,
                                              System.Globalization.NumberStyles.Any,
                                              System.Globalization.CultureInfo.InvariantCulture,
                                              out retailPrice))
                            {
                                
                                if (retailPrice > 0)
                                {
                                    savings =  (retailPrice - price) / retailPrice;
                                }
                            }

                            
                            string storeName = storeDict.ContainsKey(storeId) ? storeDict[storeId] : $"Store {storeId}";

                            
                            string dealUrl = !string.IsNullOrEmpty(dealId)
                                ? $"https://www.cheapshark.com/redirect?dealID={dealId}"
                                : string.Empty;

                            
                            result.Add(new StorePrice
                            {
                                StoreName = storeName,
                                Price = price,
                                RetailPrice = retailPrice,
                                Savings = Math.Round(savings, 2),
                                DealUrl = dealUrl
                            });

                            Console.WriteLine($"  Aggiunto: {storeName} = {price} (originale: {retailPrice}, sconto: {savings}%), URL: {dealUrl}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Errore nell'elaborazione di un deal: {ex.Message}");
                        }
                    }
                }

                Console.WriteLine($"Totale prezzi trovati: {result.Count}");

             
                return result.OrderBy(p => p.Price).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generale in GetGameStoresPricesFromCheapSharkAsync: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }

        public class StorePrice
        {
            public string StoreName { get; set; }
            public decimal Price { get; set; }
            public decimal RetailPrice { get; set; } 
            public decimal Savings { get; set; }
            public string DealUrl { get; set; } 
        }

        public class CheapSharkGame
        {
            public string GameID { get; set; }
            public string External { get; set; } 
            public string Cheapest { get; set; } 
        }

        public class CheapSharkDeal
        {
            public string DealID { get; set; }
            public string StoreID { get; set; }
            public string Price { get; set; }
            public string RetailPrice { get; set; }
            public string Savings { get; set; } 
        }

        public class CheapSharkStore
        {
            public string StoreID { get; set; }
            public string StoreName { get; set; }
        }

        private void b_vedilistagiochi_Click(object sender, EventArgs e)
        {
            var gameObjects = _listGiochi.Select(nome => new { Nome = nome }).ToList();

          
            data_listamieigiochi.DataSource = gameObjects;
        }

        private void b_rimuovigioco_Click(object sender, EventArgs e)
        {
            string nomeGiocoDaRimuovere = txt_rimuovigioco.Text.Trim();

            
            if (string.IsNullOrEmpty(nomeGiocoDaRimuovere))
            {
                MessageBox.Show("Inserisci il nome del gioco da rimuovere.", "Attenzione",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            bool rimosso = _listGiochi.Remove(nomeGiocoDaRimuovere);

            
            if (rimosso)
            {
                cbox_tuoigiochiprezzo.Items.Remove(nomeGiocoDaRimuovere);

              
                var gameObjects = _listGiochi.Select(nome => new { Nome = nome }).ToList();
                data_listamieigiochi.DataSource = gameObjects;

               
                SaveData();

                MessageBox.Show($"Il gioco '{nomeGiocoDaRimuovere}' è stato rimosso dalla lista.", "Operazione completata",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                txt_nomegioco.Clear();
            }
            else
            {
                MessageBox.Show($"Il gioco '{nomeGiocoDaRimuovere}' non è stato trovato nella lista.", "Gioco non trovato",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }



        public void SaveData()
        {
            try
            {
                
                string directory = Path.GetDirectoryName(_saveFilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                
                var dataToSave = new SavedData
                {
                    ListaGiochi = _listGiochi,
                  
                };

               
                string jsonString = JsonSerializer.Serialize(dataToSave, new JsonSerializerOptions
                {
                    WriteIndented = true 
                });

                System.IO.File.WriteAllText(_saveFilePath, jsonString);

                Console.WriteLine($"Dati salvati con successo in: {_saveFilePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante il salvataggio dei dati: {ex.Message}",
                                "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Errore durante il salvataggio: {ex}");
            }
        }

        public class SavedData
        {
            public List<string> ListaGiochi { get; set; } = new List<string>();
            public List<string> ListaGenerata { get; set; } = new List<string>();
        }


        private void LoadData()
        {
            try
            {
                if (System.IO.File.Exists(_saveFilePath))
                {
                    string jsonString = System.IO.File.ReadAllText(_saveFilePath);
                    var loadedData = JsonSerializer.Deserialize<SavedData>(jsonString);

                    if (loadedData != null)
                    {
                        // Carica i dati nelle liste
                        _listGiochi = loadedData.ListaGiochi ?? new List<string>();

                        // Aggiorna la UI con i dati caricati
                        UpdateUIFromLoadedData();

                        Console.WriteLine($"Dati caricati con successo da: {_saveFilePath}");
                    }
                }
                else
                {
                    Console.WriteLine("File di salvataggio non trovato. Verrà creato al momento della chiusura.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore durante il caricamento dei dati: {ex.Message}",
                                "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Errore durante il caricamento: {ex}");

                
                _listGiochi = new List<string>();
            }
        }

       
        private void UpdateUIFromLoadedData()
        {
            
            cbox_tuoigiochiprezzo.Items.Clear();
            foreach (var gioco in _listGiochi)
            {
                cbox_tuoigiochiprezzo.Items.Add(gioco);
            }

           

          
            var gameObjects = _listGiochi.Select(nome => new { Nome = nome }).ToList();
            data_listamieigiochi.DataSource = gameObjects;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public static class RawgApiClient
    {
        public static async Task<int?> SearchGameIdAsync(HttpClient client, string apiKey, string baseUrl, string nomeGioco)
        {
            var url = $"{baseUrl}games?key={apiKey}&search={Uri.EscapeDataString(nomeGioco)}";
            var resp = await client.GetStringAsync(url);
            var json = JObject.Parse(resp);
            var first = json["results"]?.First;
            return first?["id"]?.Value<int>();
        }

        public static async Task<string> GetGameDescriptionAsync(HttpClient client, string apiKey, string baseUrl, int gameId)
        {
            var url = $"{baseUrl}games/{gameId}?key={apiKey}";
            var resp = await client.GetStringAsync(url);
            var json = JObject.Parse(resp);
            return json["description_raw"]?.Value<string>()
                ?? json["description"]?.Value<string>()
                ?? "Descrizione non disponibile.";
        }
    }
}