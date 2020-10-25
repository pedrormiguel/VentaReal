import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogModule } from '@angular/material/dialog';
import { CarModel } from '../../class/car';
import { IResponse } from '../../class/response';
import { ApiclientService } from '../services/apiclient.service';
import { CarComponent } from '../car/car.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DialogComponent } from '../common/dialog/dialog.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {


  private _api: ApiclientService ;
  public cars: CarModel[];
  public response: IResponse;
  public columnas: string[] = ["Id","Name","Brand","Actions"];

  constructor(api: ApiclientService , public dialog: MatDialog, private _snackbar: MatSnackBar ) { 

      this._api = api;

  }

  ngOnInit(): void {

    this.getAllCars();
  }
  

  getAllCars() {

    this._api.getCar().subscribe( res => { 

      this.response = res; 
      
      this.cars = this.response.data;
  
    });
  }

  openDialog() {

    let dialogRef = this.dialog.open(CarComponent, {

        width: '250px'

    });

    dialogRef.afterClosed().subscribe( result => {

        this.getAllCars();

    }) ;
  } 

  openEdit(car: CarModel) {

    const dialogConfig = new MatDialogConfig();

    dialogConfig.data = car;

    let dialogRef = this.dialog.open(CarComponent, dialogConfig)      
      .afterClosed( )
      .subscribe( resut => {

        this._snackbar.open('Elemento editado correctamente !', 'Notification', { 

          duration: 500,

        } );

        this.getAllCars();
            
    });

  }

  deleteCar(car:CarModel) {

    const dialogConfig = new MatDialogConfig();

    let dialogRef = this.dialog.open(DialogComponent, dialogConfig)
    .afterClosed()
    .subscribe( result => {

      if(result)
        {
          this._api.deleteCar(car).subscribe( resu =>  {

            this._snackbar.open('Elemento eliminado !');
        
            this.getAllCars();
        
           } )   
        }else
        this._snackbar.open('Elemento no eliminado !');
     

    }); 

  }

  

}
