using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Coding_Tracker
{
    internal class Validation
    {

        // validate endTime should be more than startTime
        public void ValidateTime(DateTime checkStart, DateTime checkEnd)
        {
            if (checkEnd < checkStart)
            {
                Console.WriteLine("End time must be later than start time.");
                return;
            }
        }

        // check if duration is negative
        public bool isDurationNegative(TimeSpan time)
        {
            bool ts = time.Minutes > 0; 
            if (!ts)
            {
                Console.WriteLine("Time cannot be negative.");
            }
                return ts;
        }

        // check if Id exist
        public bool CheckIdExist(int id)
        {
            Controller controller = new Controller();
            bool idExist = controller.table.Any(x => x.Id == id);
            if (!idExist)
            {
                Console.WriteLine("Id does not exist. Choose another Id.");
            }
            return idExist;
        }

        // check if number is entered
        public int isNumberEntered()
        {
            bool isNumber = true;
            int numberInput;

            do
            {
                string numberString = Console.ReadLine();
                isNumber = int.TryParse(numberString, out numberInput);

                if (!isNumber || numberInput < 0)
                {
                    Console.WriteLine("Number does not exist.");
                    numberString = Console.ReadLine();
                }
            } while (!isNumber || numberInput < 0);

            return numberInput;
        }





    }
}
