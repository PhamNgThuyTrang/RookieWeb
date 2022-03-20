import React, { useState } from "react";
import { PencilFill, XCircle } from "react-bootstrap-icons";
import { useHistory } from "react-router";
import ButtonIcon from "../../../shared-components/ButtonIcon";
import { NotificationManager } from 'react-notifications';

import Table from "../../../shared-components/Table";
import Info from "../Info";
import { EDIT_BRAND_ID } from "../../../Constants/pages";
import ConfirmModal from "../../../shared-components/ConfirmModal";
import { 
  NormalBrandType,
  NormalBrandTypeLabel,
  LuxuryBrandType, 
  LuxyryBrandTypeLabel 
} from "../../../Constants/Brand/BrandConstants";
import { DisableBrandRequest } from "../Services/request"

const columns= [
  { columnName: "brandid", columnValue: "brandId" },
  { columnName: "name", columnValue: "Name" },
  { columnName: "type", columnValue: "Type" }
];

const BrandTable = ({
  brands,
  handlePage,
  handleSort,
  sortState,
  fetchData,
  query
}) => {
  const [showDetail, setShowDetail] = useState(false);
  const [brandDetail, setBrandDetail] = useState(null);
  const [disableState, setDisable] = useState({
    isOpen: false,
    id: 0,
    title: '',
    message: '',
    isDisable: true,
  });

  const handleShowInfo = (id) => {
    const brand = brands?.items.find((item) => item.brandId === id);

    if (brand) {
      setBrandDetail(brand);
      setShowDetail(true);
    }
  };

  const getBrandTypeName = (id) => {
    return id === LuxuryBrandType ? LuxyryBrandTypeLabel : NormalBrandTypeLabel;
  }

  const handleShowDisable = async (id) => {
    setDisable({
      id,
      isOpen: true,
      title: 'Are you sure',
      message: 'Do you want to disable this Brand?',
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
        `Remove Brand Successful`,
        `Remove Successful`,
        2000,
    );
    } else {
      setDisable({
        ...disableState,
        title: 'Can not disable Brand',
        message,
        isDisable: result
      });
    }
  };
    
  const handleConfirmDisable = async () => {
    let isSuccess = await DisableBrandRequest(disableState.id);
    if (isSuccess) {
      await handleResult(true, '');
    }
  };

  const handleCloseDetail = () => {
    setShowDetail(false);
  };

  const history = useHistory();
  const handleEdit = (id) => {
    const existBrand = brands?.items.find(item => item.brandId === Number(id));
    history.push(
      EDIT_BRAND_ID(id),
      {
        existBrand: existBrand
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
          currentPage: brands?.currentPage,
          totalPage: brands?.totalPages,
          handleChange: handlePage,
        }}
        fetchData={fetchData}
      >
        {brands && brands?.items?.map((data, index) => (
          <tr key={index} className="text-center" onClick={() => handleShowInfo(data.brandId)}>
            <td>{data.brandId}</td>
            <td>{data.name}</td>
            <td>{getBrandTypeName(data.type)}</td>

            <td className="d-flex justify-content-center">
              <button className="btn btn-primary" onClick={() => handleEdit(data.brandId)}>
                <ButtonIcon onClick={() => handleEdit(data.brandId)}>
                  <PencilFill className="text-black" />
                </ButtonIcon>
              </button>
              
              <button className="btn btn-danger" onClick={() => handleShowDisable(data.brandId)}>
                <ButtonIcon onClick={() => handleShowDisable(data.brandId)}>
                  <XCircle className="text-white" />
                </ButtonIcon>
              </button>
            </td>
          </tr>
        ))}
      </Table>
      {brandDetail && showDetail && (
        <Info brand={brandDetail} handleClose={handleCloseDetail} />
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
                  className="btn btn-danger m-2"
                  onClick={handleConfirmDisable}
                  type="button"
                >
                  Disable
            </button>

                <button
                  className="btn btn-outline-secondary m-2"
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

export default BrandTable;
