using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCircle.Todo.Application.Mapping.ValueConverter
{
	public static class DateTimeConverter
	{
		public static DateTime ConvertToDateTime(LocalDateTime? nodaLocalTime)
		{
			if(!nodaLocalTime.HasValue)
			{
				return DateTime.MinValue;
			}

			return nodaLocalTime.Value.ToDateTimeUnspecified();
		}

		public static LocalDateTime ConvertToNodaTime(DateTime? systemDateTime)
		{
            if (!systemDateTime.HasValue)
            {
				return LocalDateTime.MinIsoValue;
            }

            return LocalDateTime.FromDateTime(systemDateTime.Value);
		}
	}
}
