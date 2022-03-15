import React, { useState } from "react";
import { PencilFill, TicketDetailed, XCircle } from "react-bootstrap-icons";
import { useHistory } from "react-router";
import ButtonIcon from "../../../shared-components/ButtonIcon";
import { NotificationManager } from 'react-notifications';

import Table, { SortType } from "../../../shared-components/Table";
import Info from "../Info";
import { EDIT_CATEGORY_ID } from "../../../Constants/pages";
import ConfirmModal from "../../../shared-components/ConfirmModal";
import { DisableCategoryRequest } from "../Services/request"

const columns= [
  { columnName: "categoryid", columnValue: "categoryId" },
  { columnName: "name", columnValue: "Name" },
];

const CategoryTable = ({
  category,
  handlePage,
  handleSort,
  sortState,
  fetchData,
}) => {
  const [showDetail, setShowDetail] = useState(false);
  const [categoryDetail, setCategoryDetail] = useState(null);
  const [disableState, setDisable] = useState({
    isOpen: false,
    id: 0,
    title: '',
    message: '',
    isDisable: true,
  });

  const handleShowInfo = (id) => {
    const categoryInfo = category?.items.find((item) => item.categoryId === id);

    if (categoryInfo) {
      setCategoryDetail(categoryInfo);
      setShowDetail(true);
    }
  };

  const handleShowDisable = async (id) => {
    setDisable({
      id,
      isOpen: true,
      title: 'Are you sure',
      message: 'Do you want to disable this Category?',
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
        `Remove Category Successful`,
        `Remove Successful`,
        2000,
    );
    } else {
      setDisable({
        ...disableState,
        title: 'Can not disable Category',
        message,
        isDisable: result
      });
    }
  };
    
  const handleConfirmDisable = async () => {
    let isSuccess = await DisableCategoryRequest(disableState.id);
    if (isSuccess) {
      await handleResult(true, '');
    }
  };

  const handleCloseDetail = () => {
    setShowDetail(false);
  };

  const history = useHistory();
  const handleEdit = (id) => {
    const existCategory = category?.items.find(item => item.categoryId === Number(id));
    history.push(
      EDIT_CATEGORY_ID(id),
      {
        existCategory: existCategory
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
          currentPage: category?.currentPage,
          totalPage: category?.totalPages,
          handleChange: handlePage,
        }}
        
      >
        {category && category?.items?.map((data, index) => (
          <tr key={index} className="text-center" onClick={() => handleShowInfo(data.categoryId)}>
            <td>{data.categoryId}</td>
            <td>{data.name}</td>

            <td className="d-flex justify-content-center">
              <button className="btn btn-primary" onClick={() => handleEdit(data.categoryId)}>
                <ButtonIcon onClick={() => handleEdit(data.categoryId)}>
                  <PencilFill className="text-black" />
                </ButtonIcon>
              </button>
              
              <button className="btn btn-danger" onClick={() => handleShowDisable(data.categoryId)}>
                <ButtonIcon onClick={() => handleShowDisable(data.categoryId)}>
                  <XCircle className="text-white" />
                </ButtonIcon>
              </button>
            </td>
          </tr>
        ))}
      </Table>
      {categoryDetail && showDetail && (
        <Info category={categoryDetail} handleClose={handleCloseDetail} />
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

export default CategoryTable;
