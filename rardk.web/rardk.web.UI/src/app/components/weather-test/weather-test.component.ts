import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-weather-test',
  templateUrl: './weather-test.component.html',
  styleUrls: ['./weather-test.component.css'],
})
export class WeatherTestComponent {
  public forecasts?: WeatherForecast[];
  constructor(http: HttpClient) {
    http.get<WeatherForecast[]>('/api/weatherforecast').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => console.error(error)
    );
  }
}
interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
