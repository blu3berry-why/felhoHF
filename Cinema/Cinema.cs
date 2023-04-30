using System.Security.Cryptography.X509Certificates;

namespace WebSocket_VSQUVG.Cinema
{
    public class Cinema
    {
        public List<List<Seat>> seats = new List<List<Seat>>();

        private int LockIdCounter { get; set; } = 0;

        private string LockId
        {
            get {
                LockIdCounter++;
                return "lock" + LockIdCounter;
            }
        }
        

        public int Rows { get => seats?.Count ?? 0; }

        public int Cols { get => seats[0]?.Count ?? 0; }

        public Seat GetSeat(int row, int col) {
            try
            {
                return seats[row - 1][col - 1];
            }catch (Exception ex)
            {
                return null;
            }
            
        }

        public void Init(int row, int col)
        {
            seats = new List<List<Seat>>();
            for (int i = 0; i < row; i++)
            {
                seats.Add(new List<Seat>());
                for (int y = 0; y < col; y++)
                {
                    seats[0].Add(new Seat() { Row = i + 1, Column = y + 1, Status = Seat.SeatStatus.FREE });
                }
            }
        }


        public string? ReserveSeat(int row, int col)
        {
            return null;

        }
    }
}
