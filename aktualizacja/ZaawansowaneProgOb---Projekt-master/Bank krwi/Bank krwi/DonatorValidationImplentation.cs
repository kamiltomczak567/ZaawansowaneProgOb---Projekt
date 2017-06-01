using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Text.RegularExpressions;

namespace Bank_krwi {
    class DonatorValidationImplentation : IDonatorValidation {

        public void AddDonatorValidate(Donator donator) {
            if(String.IsNullOrWhiteSpace(donator.Imie)) {
                throw new ArgumentNullException("Imie jest wymagane");
            }
            if(donator.Imie.Any(char.IsDigit)) { // sprawdza, czy string zawiera jakąś cyfrę
                throw new FormatException("Imie nie może być cyfrą");
            }

            if(String.IsNullOrWhiteSpace(donator.Nazwisko)) {
                throw new ArgumentNullException("Nazwisko jest wymagane");
            }
            if(donator.Nazwisko.Any(char.IsDigit)) {
                throw new FormatException("Nazwisko nie może być cyfrą");
            }

            if(donator.Wiek < 17 || donator.Wiek > 66) {
                throw new ArgumentOutOfRangeException("Wiek musi zawierać się w przedziale 18-65");
            }
        }
    }
}
