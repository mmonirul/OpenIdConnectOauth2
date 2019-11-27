import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from './auth/auth.service';
import { AuthGuardService } from './auth/auth-guard.service';

@NgModule({
  imports: [
    CommonModule,
  ],
  declarations: [],
  providers: [
    AuthService,
    AuthGuardService
  ]
})
export class CoreModule { }