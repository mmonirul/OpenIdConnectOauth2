import { Injectable, OnDestroy, Inject } from '@angular/core';

import { UserManager, UserManagerSettings, User, WebStorageStateStore } from 'oidc-client';
import { ThrowStmt } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class AuthService implements OnDestroy{
	private manager = new UserManager(getClientSettings());
	private user: User = null;

	constructor() {
		this.manager.getUser().then(user => {
			this.user = user;
		});
	}

	isLoggedIn(): boolean {
		return this.user != null && !this.user.expired;
	}

	getClaims():any {
		var claims = this.user.profile;
		console.log(claims);

		return claims;
	}

	getAuthorizationHeaderValue(): string {
		return `${this.user.token_type} ${this.user.access_token}`;
	}

	startAuthentication(): Promise<void> {
		return this.manager.signinRedirect();
	}
	
	completeAuthentication(): Promise<void> {
		return this.manager.signinRedirectCallback().then(user => {
			this.user = user;
		});
	}

	logout() {
		this.manager.signoutCallback();
	}
	
	ngOnDestroy(): void {
		
	}
}

export function getClientSettings(): UserManagerSettings {
	return {
	  authority: 'https://localhost:44346/',
	  client_id: 'ngImplicitClient',
	  redirect_uri: 'http://localhost:4200/auth-callback',
	  post_logout_redirect_uri: 'http://localhost:4200/',
	  response_type: "id_token token",
	  scope: "openid profile roles west-test-api country subscriptionlevel",
	  filterProtocolClaims: true,
	  loadUserInfo: true,
	  userStore: new WebStorageStateStore({ store: window.localStorage })
	};
  }