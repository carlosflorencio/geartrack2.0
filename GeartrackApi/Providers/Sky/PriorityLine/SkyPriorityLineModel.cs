using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeartrackApi.Helpers;

namespace GeartrackApi.Providers.Sky.PriorityLine
{
    public class SkyPriorityLineModel
    {
        public List<Message> messages { get; set; }
        public List<Status> status { get; set; }

        public SkyPriorityLineModel(SkyPriorityLineDTO dto)
        {
            // Parse status
            status = new List<Status>();
            dto.List.Track.z0.Detail.ForEach(s => status.Add(new Status()
            {
                date = s.ondate,
                status = s.status
            }));

            status.Reverse();

            // Parse messages
            var m = dto.message.Split(@"<br/>");
            m = m.Take(m.Count() - 4).ToArray(); // remove last 4 elements (garbage)

            messages = m.Select(message =>
            {
                var idx1 = message.IndexOf(' '); // space between the date
                var idx2 = message.IndexOf(' ', idx1+1); // space separating the date & message
                var date = message.Substring(0, idx2);
                var msg = message.Substring(idx2 + 1, message.Length-idx2-1).Trim();

                return new Message()
                {
                    date = DateTime.Parse(date),
                    message = msg
                };
            }).ToList<Message>();
        }
    }

    public class Message
    {
        public DateTime date { get; set; }
        public string message { get; set; }
    }

    public class Status
    {
        public DateTime date { get; set; }
        public string status { get; set; }
    }

}
