import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: any;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<any>("https://data.police.uk/api/crimes-at-location?date=2020-02&lat=52.629729&lng=-1.131592").subscribe(result => {
      this.forecasts = result[0][0];
    }, error => console.error(error));
  }
}
