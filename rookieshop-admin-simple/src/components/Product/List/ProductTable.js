import React, { useState } from "react";
import { PencilFill, TicketDetailed, XCircle } from "react-bootstrap-icons";
import { useHistory } from "react-router";
import ButtonIcon from "../../../shared-components/ButtonIcon";
import { NotificationManager } from 'react-notifications';

import Table, { SortType } from "../../../shared-components/Table";
import Info from "../Info";
import { EDIT_PRODUCT_ID } from "../../../Constants/pages";
import ConfirmModal from "../../../shared-components/ConfirmModal";
import { DisableProductRequest } from "../Services/request"

const columns= [
  { columnName: "Product Id", columnValue: "ProductId" },
  { columnName: "Name", columnValue: "Name" },
  { columnName: "Color", columnValue: "Color" },
  { columnName: "Listed Price", columnValue: "ListedPrice" },
  { columnName: "Selling Price", columnValue: "SellingPrice" },
  { columnName: "Product Model Id", columnValue: "ProductModelId" },
  { columnName: "Image", columnValue: '' },
];

const ProductTable = ({
  product,
  handlePage,
  handleSort,
  sortState,
  fetchData,
}) => {
  const [showDetail, setShowDetail] = useState(false);
  const [productDetail, setProductDetail] = useState(null);
  const [disableState, setDisable] = useState({
    isOpen: false,
    id: 0,
    title: '',
    message: '',
    isDisable: true,
  });

  const handleShowInfo = (id) => {
    const productInfo = product?.items.find((item) => item.productId === id);

    if (productInfo) {
      setProductDetail(productInfo);
      setShowDetail(true);
    }
  };

  const handleShowDisable = async (id) => {
    setDisable({
      id,
      isOpen: true,
      title: 'Are you sure',
      message: 'Do you want to disable this Product?',
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
        `Remove Product Successful`,
        `Remove Successful`,
        2000,
    );
    } else {
      setDisable({
        ...disableState,
        title: 'Can not disable Product',
        message,
        isDisable: result
      });
    }
  };
    
  const handleConfirmDisable = async () => {
    let isSuccess = await DisableProductRequest(disableState.id);
    if (isSuccess) {
      await handleResult(true, '');
    }
  };

  const handleCloseDetail = () => {
    setShowDetail(false);
  };

  const history = useHistory();
  const handleEdit = (id) => {
    const existProduct = product?.items.find(item => item.productId === Number(id));
    history.push(
      EDIT_PRODUCT_ID(id),
      {
        existProduct: existProduct
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
          currentPage: product?.currentPage,
          totalPage: product?.totalPages,
          handleChange: handlePage,
        }}
        
      >
        {product && product?.items?.map((data, index) => (
          <tr key={index} className="" onClick={() => handleShowInfo(data.productId)}>
            <td className="text-center">{data.productId}</td>
            <td>{data.name}</td>
            <td>{data.color}</td>
            <td className="text-center">{data.listedPrice}</td>
            <td className="text-center">{data.sellingPrice}</td>
            <td className="text-center">{data.productModelId}</td>
            <td><img src={data.imagePath}></img></td>
            <td>
              <button className="btn btn-primary" onClick={() => handleEdit(data.productId)}>
                <ButtonIcon onClick={() => handleEdit(data.productId)}>
                  <PencilFill className="text-black" />
                </ButtonIcon>
              </button>
              
              <button className="btn btn-danger" onClick={() => handleShowDisable(data.productId)}>
                <ButtonIcon onClick={() => handleShowDisable(data.productId)}>
                  <XCircle className="text-white" />
                </ButtonIcon>
              </button>
            </td>
          </tr>
        ))}
      </Table>
      {productDetail && showDetail && (
        <Info product={productDetail} handleClose={handleCloseDetail} />
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

export default ProductTable;
