using WebSocket_VSQUVG.Types.Res;

namespace WebSocket_VSQUVG.Cinema
{
    public class Seat
    {
        public enum SeatStatus {
            FREE,
            LOCKED,
            RESERVED
        }

        public string StatusString(SeatStatus status) {
            switch (status)
            {
                case SeatStatus.FREE:
                    return "free";
                    break;
                case SeatStatus.LOCKED:
                    return "locked";
                    break;
                case SeatStatus.RESERVED:
                    return "reserved";
                    break;
                default:
                    return "free";
            }

        }

        public int Row { get; set; }
        public int Column { get; set; }

        public SeatStatus Status { get; set; }

        public string Status_string { get => StatusString(Status); }
    }
}
