const Endpoints = {
    authorize: 'api/authorize',
    me: 'api/authorize/me',
    
    brand: '/api/brands',
    brandId: (id) => `api/brands/${id}`,

    category: '/api/categories',
    categoryId: (id) => `api/categories/${id}`,

    getsubcategories: '/api/subcategories/getsubcategories',
    createsubcategory: '/api/subcategories/postsubcategory',
    putsubcategory: (id) => `api/subcategories/putsubcategory/${id}`,
    deletesubcategory: (id) => `api/subcategories/deletesubcategory/${id}`,

    getproducts: '/api/products/getproducts',
    createproduct: '/api/products/postproduct',
    putproduct: (id) => `api/products/putproduct/${id}`,
    deleteproduct: (id) => `api/products/deleteproduct/${id}`,

    productImage: '/api/productimages',
    productImageId: (id) => `api/productimages/${id}`,

};

export default Endpoints;
