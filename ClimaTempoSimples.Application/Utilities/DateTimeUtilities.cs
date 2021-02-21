using System;

namespace ClimaTempoSimples.Application.Utilities
{
    public static class DateTimeUtilities
    {
        public static string GetWeekDayPortugueseTranslation(DayOfWeek dayOfWeek, bool setFirstLetterToUpperCase = true, bool appendFeiraSuffix = false)
        {
            switch(dayOfWeek)
            {
                case DayOfWeek.Sunday: return (setFirstLetterToUpperCase ? "D" : "d") + "omingo";
                case DayOfWeek.Monday: return (setFirstLetterToUpperCase ? "S" : "s") + "egunda" + (appendFeiraSuffix ? "-feira" : string.Empty);
                case DayOfWeek.Tuesday: return (setFirstLetterToUpperCase ? "T" : "t") + "erça" + (appendFeiraSuffix ? "-feira" : string.Empty);
                case DayOfWeek.Wednesday: return (setFirstLetterToUpperCase ? "Q" : "q") + "uarta" + (appendFeiraSuffix ? "-feira" : string.Empty);
                case DayOfWeek.Thursday: return (setFirstLetterToUpperCase ? "Q" : "q") + "uinta" + (appendFeiraSuffix ? "-feira" : string.Empty);
                case DayOfWeek.Friday: return (setFirstLetterToUpperCase ? "S" : "s") + "exta" + (appendFeiraSuffix ? "-feira" : string.Empty);
                case DayOfWeek.Saturday: return (setFirstLetterToUpperCase ? "S" : "s") + "ábado";
            }

            return null;
        }
    }
}
