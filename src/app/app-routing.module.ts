import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeDetailComponent } from './employee/employee-detail/employee-detail.component';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';

const appRoutes: Routes = [
    { path: 'employee-list', component: EmployeeListComponent },
    { path: 'employee-detail', component: EmployeeDetailComponent },
    { path: '', redirectTo: '/employee-list', pathMatch: 'full' },
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes, {
        onSameUrlNavigation: 'reload'
    })],
    exports: [RouterModule]
})
export class AppRoutingModule { }
