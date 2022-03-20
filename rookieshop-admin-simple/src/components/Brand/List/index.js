import React, { useEffect, useState } from "react";
import { FunnelFill } from "react-bootstrap-icons";
import { Search } from "react-feather";
import ReactMultiSelectCheckboxes from "react-multiselect-checkboxes";

import { Link } from "react-router-dom";
import BrandTable from "./BrandTable";

import { FilterBrandTypeOptions } from "../../../Constants/selectOptions";
import { getBrandsRequest } from "../Services/request"
import { 
  ACCSENDING, 
  DECSENDING, 
  DEFAULT_BRAND_SORT_COLUMN_NAME,
  DEFAULT_PAGE_LIMIT
} from "../../../Constants/paging"

const ListBrand = () => {
  const [query, setQuery] = useState({
    page: 1,
    limit: DEFAULT_PAGE_LIMIT,
    sortOrder: DECSENDING,
    sortColumn: DEFAULT_BRAND_SORT_COLUMN_NAME
  });
  const [search, setSearch] = useState("");
  const [brands, setBrands] = useState("");
  const [canceled, setCanceled] = useState(false);
  const [selectedType, setSelectedType] = useState([
    { id: 1, label: "All", value: 0 },
  ]);

  const handleType = (selected) => {
    if (selected.length === 0) {
      setQuery({
        ...query,
        types: [],
      });

      setSelectedType([FilterBrandTypeOptions[0]]);
      return;
    }

    const selectedAll = selected.find((item) => item.id === 1);
    setSelectedType((prevSelected) => {
      if (!prevSelected.some((item) => item.id === 1) && selectedAll) {
        setQuery({
          ...query,
          types: [],
        });

        return [selectedAll];
      }

      const newSelected = selected.filter((item) => item.id !== 1);
      const types = newSelected.map((item) => item.value);

      setQuery({
        ...query,
        types,
      });

      return newSelected;
    });
  };

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
    let data = await getBrandsRequest(query);
    console.log('fetchDataCallbackAsync');
    console.log(data);
    await setBrands(data);
    await setCanceled(false);
  }

  useEffect(() => {
    async function fetchDataAsync() {
      let result = await getBrandsRequest(query);
      await setBrands(result.data);
      await setCanceled(true);
    }

    fetchDataAsync();
  }, [query, canceled]);

  return (
    <>
      <div className="primaryColor text-title intro-x">Brand List</div>
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

        <div className="w-md mt-3 justify-content-between row">
          <div className="col-4 d-flex flex-row ">
              <ReactMultiSelectCheckboxes
                  options={FilterBrandTypeOptions}
                  hideSearch={true}
                  placeholderButtonLabel="Type"
                  value={selectedType}
                  onChange={handleType}
                />
            <div className="border p-2">
              <FunnelFill />
            </div>              
          </div>
        
          <div className="d-flex flex-row-reverse col-4">
            <Link to="/brand/create" type="button" className="btn btn-primary">
              Create new Brand
            </Link>
          </div>
        </div>
      </div>

        <div className="row justify-content-center">
          <div className="col-md-10">
            <BrandTable
              brands={brands}
              handlePage={handlePage}
              handleSort={handleSort}
              sortState={{
                columnValue: query.sortColumn,
                orderBy: query.sortOrder,
              }}
              fetchData={fetchDataCallbackAsync}
              query = {query}
            />
          </div>
        </div>
    </>
  );
};

export default ListBrand;
