using System.ComponentModel.DataAnnotations;

public class Payment
{
    [Key]
    public int PaymentId { get; set; }

    [Required]
    public int ReservationId { get; set; }

    public Reservation? Reservation { get; set; }

    [Required]
    public int RoomId { get; set; }

    public Room? Room { get; set; }

    [Required]
    public int TransactionId { get; set; }

    [Range(0, int.MaxValue)]
    public int Amount { get; set; }

    [DataType(DataType.Date)]
    public DateTime PaymentDate { get; set; }

    [Required]
    public PaymentTypeEnum PaymentType { get; set; }
}

public enum PaymentTypeEnum
{
    Cash,
    CreditCard,
    DebitCard,
    UPI,
    NetBanking
}
