namespace BetStackAppApi.DataObjects
{
    public class SiteItems
    {
        public string site_key { get; set; }
        public string site_nice { get; set; }
        public string last_update { get; set; }
        public EventOdds odds { get; set; }
    }
}
