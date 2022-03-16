import React, { useState } from "react";
import { PencilFill, TicketDetailed, XCircle } from "react-bootstrap-icons";
import { useHistory } from "react-router";
import ButtonIcon from "../../../shared-components/ButtonIcon";
import { NotificationManager } from 'react-notifications';

import Table, { SortType } from "../../../shared-components/Table";
import Info from "../Info";
import { EDIT_PRODUCT_ID } from "../../../Constants/pages";
import ConfirmModal from "../../../shared-components/ConfirmModal";
import { DisableSubCategoryRequest } from "../Services/request"

const columns= [
  { columnName: "SubCategory Id", columnValue: "SubCategoryId" },
  { columnName: "Name", columnValue: "Name" },
  { columnName: "Category", columnValue: "Category" },
];

const SubCategoryTable = ({
  subcategory,
  handlePage,
  handleSort,
  sortState,
  fetchData,
}) => {
  const [showDetail, setShowDetail] = useState(false);
  const [subcategoryDetail, setSubCategoryDetail] = useState(null);
  const [disableState, setDisable] = useState({
    isOpen: false,
    id: 0,
    title: '',
    message: '',
    isDisable: true,
  });

  const handleShowInfo = (id) => {
    const subcategoryInfo = subcategory?.items.find((item) => item.subcategoryId === id);

    if (subcategoryInfo) {
      setSubCategoryDetail(subcategoryInfo);
      setShowDetail(true);
    }
  };

  const handleShowDisable = async (id) => {
    setDisable({
      id,
      isOpen: true,
      title: 'Are you sure',
      message: 'Do you want to disable this SubCategory?',
      isDisable: true,
    });
  };

  const handleCloseDisable = () => {
    setDisable({
      isOpen: false,
      id: 0,
      title: '',
      message: '',
      isDisable: true,
    });
  };

  const handleResult = async (result, message) => {
    if (result) {
      handleCloseDisable();
      await fetchData();
      NotificationManager.success(
        `Remove SubCategory Successful`,
        `Remove Successful`,
        2000,
    );
    } else {
      setDisable({
        ...disableState,
        title: 'Can not disable SubCategory',
        message,
        isDisable: result
      });
    }
  };
    
  const handleConfirmDisable = async () => {
    let isSuccess = await DisableSubCategoryRequest(disableState.id);
    if (isSuccess) {
      await handleResult(true, '');
    }
  };

  const handleCloseDetail = () => {
    setShowDetail(false);
  };

  const history = useHistory();
  const handleEdit = (id) => {
    const existSubCategory = subcategory?.items.find(item => item.subcategoryId === Number(id));
    history.push(
      EDIT_PRODUCT_ID(id),
      {
        existSubCategory: existSubCategory
      }
    );
  };

  return (
    <>
      <Table
        columns={columns}
        handleSort={handleSort}
        sortState={sortState}
        page={{
          currentPage: subcategory?.currentPage,
          totalPage: subcategory?.totalPages,
          handleChange: handlePage,
        }}
        
      >
        {subcategory && subcategory?.items?.map((data, index) => (
          <tr key={index} className="text-center" onClick={() => handleShowInfo(data.subcategoryId)}>
            <td>{data.subCategoryId}</td>
            <td>{data.name}</td>
            <td>{data.category.name}</td>
            <td>
              <button className="btn btn-primary" onClick={() => handleEdit(data.subcategoryId)}>
                <ButtonIcon onClick={() => handleEdit(data.subcategoryId)}>
                  <PencilFill className="text-black" />
                </ButtonIcon>
              </button>
              
              <button className="btn btn-danger" onClick={() => handleShowDisable(data.subcategoryId)}>
                <ButtonIcon onClick={() => handleShowDisable(data.subcategoryId)}>
                  <XCircle className="text-white" />
                </ButtonIcon>
              </button>
            </td>
          </tr>
        ))}
      </Table>
      {subcategoryDetail && showDetail && (
        <Info subcategory={subcategoryDetail} handleClose={handleCloseDetail} />
      )}

      <ConfirmModal
        title={disableState.title}
        isShow={disableState.isOpen}
        onHide={handleCloseDisable}
      >
        <div>
          <div className="text-center">
            {disableState.message}
          </div>
          {
            disableState.isDisable && (
              <div className="text-center mt-3">
                <button
                  className="btn btn-danger mr-3"
                  onClick={handleConfirmDisable}
                  type="button"
                >
                  Disable
                </button>

                <button
                  className="btn btn-outline-secondary"
                  onClick={handleCloseDisable}
                  type="button"
                >
                  Cancel
            </button>
              </div>
            )
          }
        </div>
      </ConfirmModal>
    </>
  );
};

export default SubCategoryTable;
