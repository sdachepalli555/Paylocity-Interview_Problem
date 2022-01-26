import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { AppRoutingModule } from './app-routing.module';
import { EmployeeService } from './Shared/employee.service';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';
import { MatTableModule } from '@angular/material/table';
import { EmployeeDetailComponent } from './employee/employee-detail/employee-detail.component';

@NgModule({  
  declarations: [
    AppComponent,
    HeaderComponent,
    EmployeeListComponent,
    EmployeeDetailComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,
    MatTableModule
  ],
  providers: [EmployeeService],  
  bootstrap: [AppComponent]
})
export class AppModule {}
