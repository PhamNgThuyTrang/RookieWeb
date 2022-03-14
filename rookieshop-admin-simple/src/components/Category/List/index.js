import React, { useEffect, useState } from "react";
import { Search } from "react-feather";

import { Link } from "react-router-dom";
import CategoryTable from "./CategoryTable";
import { getCategoryRequest } from "../Services/request"

import { 
  ACCSENDING, 
  DECSENDING, 
  DEFAULT_CATEGORY_SORT_COLUMN_NAME,
  DEFAULT_PAGE_LIMIT
} from "../../../Constants/paging"

const ListCategory = () => {
  const [query, setQuery] = useState({
    page: 1,
    limit: DEFAULT_PAGE_LIMIT,
    sortOrder: DECSENDING,
    sortColumn: DEFAULT_CATEGORY_SORT_COLUMN_NAME
  });
  const [search, setSearch] = useState("");
  const [category, setCategory] = useState("");

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
    let data = await getCategoryRequest(query);
    console.log('fetchDataCallbackAsync');
    console.log(data);
    setCategory(data);
  }

  useEffect(() => {
    async function fetchDataAsync() {
      let result = await getCategoryRequest(query);
      setCategory(result.data);
    }

    fetchDataAsync();
  }, [query]);

  return (
    <>
      <div className="primaryColor text-title intro-x">Category List</div>
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
            <Link to="/category/create" type="button" className="btn btn-danger">
              Create new Category
            </Link>
          </div>
        </div>

        <CategoryTable
          category={category}
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

export default ListCategory;
