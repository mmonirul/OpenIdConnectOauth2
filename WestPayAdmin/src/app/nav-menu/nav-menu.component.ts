import { Component } from '@angular/core';
import { AuthService } from '../core/auth/auth.service';
import { Subscriber, Subscription } from 'rxjs';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  isAuthorized = false;
  isAuthorizedSubscription: Subscription  = new Subscription;
  
  constructor(private authService: AuthService) {
  }


  logout(){
    console.log('logout...');
    this.authService.logout();
  }
  ngOnDestroy(): void {
    this.isAuthorizedSubscription.unsubscribe();
  }
  
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
