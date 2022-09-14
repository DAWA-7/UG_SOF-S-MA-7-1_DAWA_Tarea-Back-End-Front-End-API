namespace SOF_S_MA_7_1_TAREA_Back_End_Front_End_API {
    public class WeatherForecast {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}