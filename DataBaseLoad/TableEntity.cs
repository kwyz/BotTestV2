using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBaseLoad
{
    public class ElementEntity : TableEntity
    {
        public ElementEntity(string text)
        {
            this.PartitionKey = text;
        }
    }
}