export const SIGNIN = '/authentication/signin';
export const SIGNINCALLBACK = '/authentication/signin-oidc';
export const SIGNOUT = '/authentication/signout';
export const AUTH = '/authentication/:action';
export const HOME = '/';

export const BRAND = '/brand';
export const CREATE_BRAND = '/brand/create';
export const EDIT_BRAND = '/brand/edit/:id';
export const EDIT_BRAND_ID = (id) => `/brand/edit/${id}`;

export const CATEGORY = '/category';
export const CREATE_CATEGORY = '/category/create';
export const EDIT_CATEGORY = '/category/edit/:id';
export const EDIT_CATEGORY_ID = (id) => `/category/edit/${id}`;

export const SUBCATEGORY = '/subcategory';
export const CREATE_SUBCATEGORY = '/subcategory/create';
export const EDIT_SUBCATEGORY = '/subcategory/edit/:id';
export const EDIT_SUBCATEGORY_ID = (id) => `/subcategory/edit/${id}`;

export const PRODUCTMODEL = '/productmodel';
export const CREATE_PRODUCTMODEL = '/productmodel/create';
export const EDIT_PRODUCTMODEL = '/productmodel/edit/:id';
export const EDIT_PRODUCTMODEL_ID = (id) => `/productmodel/edit/${id}`;

export const PRODUCT = '/product';
export const CREATE_PRODUCT = '/product/create';
export const EDIT_PRODUCT = '/product/edit/:id';
export const EDIT_PRODUCT_ID = (id) => `/product/edit/${id}`;

export const PRODUCTIMAGE = '/productimage';
export const CREATE_PRODUCTIMAGE = '/productimage/create';
export const EDIT_PRODUCTIMAGE = '/productimage/edit/:id';
export const EDIT_PRODUCTIMAGE_ID = (id) => `/productimage/edit/${id}`;

export const UNAUTHORIZE = '/unauthorize';
export const NOTFOUND = '/notfound';