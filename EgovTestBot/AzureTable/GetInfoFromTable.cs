using System;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
    
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace EgovTestBot.AzureTable
{
    public class GetInfoFromTable : TableEntity
    {
        public string Adresa { get; set; }
        public string CerereOnline { get; set; }
        public string Contact { get; set; }
        public string Costul { get; set; }
        public string Descrierea { get; set; }
        public string Documente { get; set; }
        public string Programul { get; set; }
        public string TipPersoana { get; set; }
        public string ErrorQuery { set; get; }

        public string By(string firstQueryElement, string seccondQueryElement) {

            string queryResult = null;
            
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("" +
           "DefaultEndpointsProtocol=https;AccountName=egovtestbotae3a;AccountKey=HMZbdHjseB8xd8kc8bJgn1ch9R3h2glxFlVZRJCUrnDWtmcZyE11BHD5rkRM6WfjoqrTlS0TJ2GJ8fjKOXSNdA==;EndpointSuffix=core.windows.net");

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("botdata");
            TableOperation retrieveOperation = TableOperation.Retrieve<GetInfoFromTable>("Servicii", seccondQueryElement);
            

            TableResult retrievedResult = table.Execute(retrieveOperation);
            if (retrievedResult.Result != null)
            {
                switch (firstQueryElement)
                {
                    case "Cerereonline":
                        queryResult = (((GetInfoFromTable)retrievedResult.Result).CerereOnline);
                        break;
                    case "Adresa si datele de contact":
                        queryResult = (((GetInfoFromTable)retrievedResult.Result).Adresa+""+ ((GetInfoFromTable)retrievedResult.Result).Contact);
                        break;
                    case "Costul prestarii serviciului":
                        queryResult = (((GetInfoFromTable)retrievedResult.Result).Costul);
                        break;
                    case "Informatie generala":
                        queryResult = (((GetInfoFromTable)retrievedResult.Result).Descrierea);
                        break;
                    case "Documentele necesare":
                        queryResult = (((GetInfoFromTable)retrievedResult.Result).Documente);
                        break;
                    case "Program de lucru":
                        queryResult = (((GetInfoFromTable)retrievedResult.Result).Programul);
                        break;
                    case "TipPersoana":
                        queryResult = (((GetInfoFromTable)retrievedResult.Result).TipPersoana);
                        break;
                    case "Acte normative":
                        queryResult = (((GetInfoFromTable)retrievedResult.Result).TipPersoana);
                        break;
                    default:
                        queryResult = "Și uaiiiiiiii!";
                        break;
                }
                return queryResult;
            }
            else
            {
                return "Nu am gasit așa informație ";
            }
            
        }
    }
}