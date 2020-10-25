import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CarModel } from 'src/class/car';
import { ApiclientService } from '../services/apiclient.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})

export class CarComponent implements OnInit {

  public car = new CarModel()

  constructor(
    private apicliente: ApiclientService,
    private dialogRef: MatDialogRef<CarComponent>,
    @Inject(MAT_DIALOG_DATA) data) { 

      
      if(data) {

        this.car.Name  = data["name"];
        this.car.Brand = data["brand"];
        this.car.Id  = data["id"];

      }else {
        this.car.Id = 0;
      }

  }

  ngOnInit(): void {

  
  }

   addCar() {

    this.apicliente.addCar(this.car).subscribe (
      respo =>  
          console.log(respo)
    );

    this.closeComponent()

  }

  closeComponent(){
    this.dialogRef.close();
  }

   updateCar() {

    this.apicliente.updateCar(this.car).subscribe( result => console.log( result ) );

    this.closeComponent();

  }

}
