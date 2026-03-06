using EcoPark_Animal_Management_System.enums;

namespace EcoPark_Animal_Management_System
{
    // Interface defining the contract for all animals
    public interface IAnimal
    {
        string Name { get; set; }                  // Animal's name
        int Age { get; set; }                      // Animal's age
        GenderType Gender { get; set; }            // Animal's gender
        string ToStringSummary();                   // Returns summary for list display
    }
}