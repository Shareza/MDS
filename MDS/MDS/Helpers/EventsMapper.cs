using System;
using System.Collections.Generic;
using System.Text;

namespace MDS.Helpers
{
    public static class EventsMapper
    {
        public static string GetName(int number)
        {
            string temp = String.Empty;

            switch (number)
            {
                case 1:
                    temp = "Strzyżenie Męskie";
                    break;

                case 2:
                    temp = "Strzyżenie Damskie";
                    break;

                case 3:
                    temp = "Koloryzacja";
                    break;

                default:
                    temp = "Unknown";
                    break;
            }

            return temp;
        }
    }
}