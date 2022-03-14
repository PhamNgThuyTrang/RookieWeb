import React, { useEffect, useState } from "react";
import { Search } from "react-feather";

import { Link } from "react-router-dom";
import ProductTable from "./ProductTable";
import { getProductRequest } from "../Services/request"

import { 
  ACCSENDING, 
  DECSENDING, 
  DEFAULT_PRODUCT_SORT_COLUMN_NAME,
  DEFAULT_PAGE_LIMIT
} from "../../../Constants/paging"

const ListProduct = () => {
  const [query, setQuery] = useState({
    page: 1,
    limit: DEFAULT_PAGE_LIMIT,
    sortOrder: DECSENDING,
    sortColumn: DEFAULT_PRODUCT_SORT_COLUMN_NAME
  });
  const [search, setSearch] = useState("");
  const [product, setProduct] = useState("");

  const handleChangeSearch = (e) => {
    e.preventDefault();

    const search = e.target.value;
    setSearch(search);
  };

  const handleSearch = () => {
    setQuery({
      ...query,
      search,
    });
  };

  const handlePage = (page) => {
    setQuery({
      ...query,
      page,
    });
  };

  const handleSort = (sortColumn) => {
    const sortOrder = query.sortOrder === ACCSENDING ? DECSENDING : ACCSENDING;

    setQuery({
      ...query,
      sortColumn,
      sortOrder,
    });
  };

  const fetchDataCallbackAsync = async () =>  {
    let data = await getProductRequest(query);
    console.log('fetchDataCallbackAsync');
    console.log(data);
    setProduct(data);
  }

  useEffect(() => {
    async function fetchDataAsync() {
      let result = await getProductRequest(query);
      setProduct(result.data);
    }

    fetchDataAsync();
  }, [query]);

  return (
    <>
      <div className="primaryColor text-title intro-x">Product List</div>
      <div>
        <div className="d-flex mb-5 intro-x">
          <div className="d-flex align-items-center w-ld ml-auto">
            <div className="input-group">
              <input
                onChange={handleChangeSearch}
                value={search}
                type="text"
                className="form-control"
              />
              <span onClick={handleSearch} className="border p-2 pointer">
                <Search />
              </span>
            </div>
          </div>

          <div className="d-flex align-items-center ml-3">
            <Link to="/product/create" type="button" className="btn btn-danger">
              Create new Product
            </Link>
          </div>
        </div>

        <ProductTable
          product={product}
          handlePage={handlePage}
          handleSort={handleSort}
          sortState={{
            columnValue: query.sortColumn,
            orderBy: query.sortOrder,
          }}
          fetchData={fetchDataCallbackAsync}
          
        />
      </div>
    </>
  );
};

export default ListProduct;
