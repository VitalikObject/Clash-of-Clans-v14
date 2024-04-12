using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClashofClans.Logic.Manager.Items
{
    public class SuperLicences
    {
        [JsonProperty("licence_ends")]
        public List<int> LicenceEnds { get; set; }
    }
}
