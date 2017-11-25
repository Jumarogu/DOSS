
interface AuthConfig {
    clientID: string;
    domain: string;
    callbackURL: string;
  }
  
  export const AUTH_CONFIG: AuthConfig = {
    clientID: 'x5wyKjBsZabsdJM9QH28jMCcs37YQSxS',
    domain: 'doss-auth.auth0.com',
    callbackURL: 'http://localhost:4200/callback'
  };