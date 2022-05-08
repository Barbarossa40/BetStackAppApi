namespace BetStackAppApi.DataObjects
{
    public class BetEventsAndSites
    {
        public string id { get; set; }
        public string sport_key { get; set; }
        public string sport_nice { get; set; }
        public List<string> teams { get; set; }
        public string commence_time { get; set; }

        public List<SiteItems> sites { get; set; }

    }
}
