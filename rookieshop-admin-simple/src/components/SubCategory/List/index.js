import React, { useEffect, useState } from "react";
import { Search } from "react-feather";

import { Link } from "react-router-dom";
import SubCategoryTable from "./SubCategoryTable";
import { getSubCategoryRequest } from "../Services/request"

import { 
  ACCSENDING, 
  DECSENDING, 
  DEFAULT_SUBCATEGORY_SORT_COLUMN_NAME,
  DEFAULT_PAGE_LIMIT
} from "../../../Constants/paging"

const ListSubCategory = () => {
  const [query, setQuery] = useState({
    page: 1,
    limit: DEFAULT_PAGE_LIMIT,
    sortOrder: DECSENDING,
    sortColumn: DEFAULT_SUBCATEGORY_SORT_COLUMN_NAME
  });
  const [search, setSearch] = useState("");
  const [canceled, setCanceled] = useState(false);
  const [subcategory, setSubCategory] = useState("");

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
    let data = await getSubCategoryRequest(query);
    console.log('fetchDataCallbackAsync');
    console.log(data);
    await setSubCategory(data);
    await setCanceled(false);
  }

  useEffect(() => {
    async function fetchDataAsync() {
      let result = await getSubCategoryRequest(query);
      await setSubCategory(result.data);
      await setCanceled(true);
    }

    fetchDataAsync();
  }, [query, canceled]);

  return (
    <>
      <div className="primaryColor text-title intro-x">SubCategory List</div>
      <div className="mx-auto mb-5 intro-x w-75">
        <div className="w-ld ml-auto">
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

        <div className="mt-3 d-flex flex-row-reverse">
          <Link to="/subcategory/create" type="button" className="btn btn-primary">
            Create new SubCategory
          </Link>
        </div>
      </div>
      
      <div className="row justify-content-center">
        <div className="col-md-10">
          <SubCategoryTable
            subcategory={subcategory}
            handlePage={handlePage}
            handleSort={handleSort}
            sortState={{
              columnValue: query.sortColumn,
              orderBy: query.sortOrder,
            }}
            fetchData={fetchDataCallbackAsync}          
          />
        </div>
      </div>
    </>
  );
};

export default ListSubCategory;
