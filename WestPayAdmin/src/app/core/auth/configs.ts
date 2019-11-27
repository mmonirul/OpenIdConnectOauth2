
export function getOpenIdConfiguration(authUrl: string){
	 const openIdConfiguration = {
		stsServer: authUrl,
		redirect_url: `${this.originUrl}callback`,
		client_id: 'ngCodeClient',
		response_type: 'code',
		scope: 'openid profile west-test-api', //'openid profile roles west-test-api address'
		post_logout_redirect_uri: this.originUrl,
		forbidden_route: '/forbidden',
		unauthorized_route: '/unauthorized',
		silent_renew: true,
		silent_renew_url: `${this.originUrl}silent-renew.html`,
		history_cleanup_off: true,
		auto_userinfo: true,
		log_console_debug_active: true,
		log_console_warning_active: true,
		max_id_token_iat_offset_allowed_in_seconds: 10
	};
	return openIdConfiguration;
}
export function getAuthWellKnownEndpoints(authUrl: string){
	const authWellKnownEndpoints = {
		issuer: authUrl,
		jwks_uri: authUrl + '/.well-known/openid-configuration/jwks',
		authorization_endpoint: authUrl + '/connect/authorize',
		token_endpoint: authUrl + '/connect/token',
		userinfo_endpoint: authUrl + '/connect/userinfo',
		end_session_endpoint: authUrl + '/connect/endsession',
		check_session_iframe: authUrl + '/connect/checksession',
		revocation_endpoint: authUrl + '/connect/revocation',
		introspection_endpoint: authUrl + '/connect/introspect',
	};	
	
	return authWellKnownEndpoints;
}
