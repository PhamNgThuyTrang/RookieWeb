import React, { useEffect, useState } from "react";
import { Search } from "react-feather";
import UserTable from "./UserTable";
import { getUserRequest } from "./Services/request"

import { 
  ACCSENDING, 
  DECSENDING, 
  DEFAULT_USER_SORT_COLUMN_NAME,
  DEFAULT_PAGE_LIMIT
} from "../../Constants/paging"

export function User(){
  const [query, setQuery] = useState({
    page: 1,
    limit: DEFAULT_PAGE_LIMIT,
    sortOrder: DECSENDING,
    sortColumn: DEFAULT_USER_SORT_COLUMN_NAME
  });
  const [search, setSearch] = useState("");
  const [user, setUser] = useState("");

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
    let data = await getUserRequest(query);
    console.log('fetchDataCallbackAsync');
    console.log(data);
    setUser(data);
  }

  useEffect(() => {
    async function fetchDataAsync() {
      let result = await getUserRequest(query);
      setUser(result.data);
    }

    fetchDataAsync();
  }, [query]);

  return (
    <>
      <div className="primaryColor text-title intro-x">User List</div>
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
      </div>
      
      <div className="row justify-content-center">
        <div className="col-md-10">
          <UserTable
            user={user}
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
}

