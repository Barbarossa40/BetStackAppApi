namespace BetStackAppApi.DataObjects
{
    public class BetEventsBySport
    {
        public bool success { get; set; }
        public List<BetEventsAndSites> data { get; set; }
    }
}
