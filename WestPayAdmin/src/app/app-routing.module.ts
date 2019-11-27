import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProtectedComponent } from './protected/protected.component';
import { CounterComponent } from './counter/counter.component';
import { HomeComponent } from './home/home.component';
import { BookComponent } from "./books/Book.Component";
import { AuthGuardService } from './core/auth/auth-guard.service';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';


const routes: Routes = [
    // {
    //     path: '',
    //     children: []
	// },
	{ path: '', component: HomeComponent, pathMatch: 'full' },
	{ path: 'counter', component: CounterComponent },
    { path: 'books', component: BookComponent, canActivate: [AuthGuardService] },
    {
        path: 'auth-callback',
        component: AuthCallbackComponent
    },
    {
        path: 'protected',
        component: ProtectedComponent,
        canActivate: [AuthGuardService]
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }

