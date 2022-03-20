export const UrlBackEnd = process.env.REACT_APP_BACKEND_URL;

export const URL = process.env.REACT_APP_URL ?? "http://localhost:3000";

export const ClientId = "admin";

export const RedirectUri = "http://localhost:3000/Authentication/signin-oidc";

export const Scope = "openid profile rookieshop.api";

export const ResponseType = "id_token token";

export const PostLogoutRedirectUri = "http://localhost:3000/";
