import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from '../core/auth/auth.service';

@Component({
	selector: 'book',
	templateUrl: './book.component.html'
})
export class BookComponent implements OnInit {
	response: Object;

	constructor(private authService: AuthService, private http: HttpClient, @Inject('API_URL') private apiUrl: string,  @Inject('AUTH_URL') authUrl: string) {
		
	}

	ngOnInit(): void {
		let headers = new HttpHeaders({ 'Authorization': this.authService.getAuthorizationHeaderValue() });

        this.http.get(`${this.apiUrl}/api/books`, { headers: headers })
          .subscribe(response => this.response = response);
	}

}
