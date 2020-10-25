import { Breakpoints } from '@angular/cdk/layout';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IResponse } from 'src/class/response'
import { CarModel } from '../../class/car';
 
@Injectable({
  providedIn: 'root'
})

export class ApiclientService {

  constructor(private http: HttpClient) {}

   public header = new HttpHeaders({
      'Content-Type': 'application/json',
   });

  public url: string = "https://localhost:8081/api/car";

  getCar(): Observable<IResponse> {
    return this.http.get<IResponse>(this.url) ;
  }

  addCar(car: CarModel): Observable<IResponse> {
    return this.http.post<IResponse>( this.url, car );
  }

  deleteCar(car: any): Observable<IResponse> {

    
    return this.http.delete<IResponse>( `${this.url}/${car.id}`,  { headers:this.header} );

  }

  updateCar(car: any): Observable<IResponse> {

    return this.http.put<IResponse>( this.url , car);

  }


}
 