namespace WebApiVS.Contracts.Model.Rooms
{
    public class GetRoomsResponse
    {
        public int RoomAmount { get; set; }
        public RoomView[] Rooms { get; set; }
    }
}
