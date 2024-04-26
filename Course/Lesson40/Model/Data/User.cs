using System.ComponentModel.DataAnnotations;

public class User
{

    public int ID { get; set; }
    [Required]
    [StringLength(maximumLength: 255)]
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public double Reward { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
}