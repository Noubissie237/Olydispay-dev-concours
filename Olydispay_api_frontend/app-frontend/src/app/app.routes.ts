import { Routes } from '@angular/router';
import { EmployeeComponent } from './employee/employee.component';
import { DepartmentComponent } from './department/department.component';
import { GradeHistoryComponent } from './grade-history/grade-history.component';

export const routes: Routes = [
    {path: 'employee', component: EmployeeComponent},
    {path: 'department', component: DepartmentComponent},
    {path: 'gradehistory', component: GradeHistoryComponent}
];
