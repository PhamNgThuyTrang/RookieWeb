import React, { useState } from "react";
import { useHistory } from "react-router";
import Table from "../../shared-components/Table";
import Info from "./Info";

const columns= [
  { columnName: "User Name", columnValue: "UserName" },
  { columnName: "Full Name", columnValue: "Full Name" },
  { columnName: "Email", columnValue: "Email" },
  { columnName: "Phone Number", columnValue: "PhoneNumber" },
];

const UserTable = ({
  user,
  handlePage,
  handleSort,
  sortState,
  fetchData,
}) => {
  const [showDetail, setShowDetail] = useState(false);
  const [userDetail, setUserDetail] = useState(null);

  const handleShowInfo = (email) => {
    const userInfo = user?.items.find((item) => item.email === email);

    if (userInfo) {
      setUserDetail(userInfo);
      setShowDetail(true);
    }
  };

  const handleCloseDetail = () => {
    setShowDetail(false);
  };

  const history = useHistory();

  return (
    <>
      <Table
        columns={columns}
        handleSort={handleSort}
        sortState={sortState}
        page={{
          currentPage: user?.currentPage,
          totalPage: user?.totalPages,
          handleChange: handlePage,
        }}
        
      >
        {user && user?.items?.map((data, index) => (
          <tr key={index} className="text-center" onClick={() => handleShowInfo(data.email)}>
            <td className="text-capitalize">{data.userName}</td>
            <td>{data.fullName}</td>
            <td>{data.email}</td>
            <td>{data.phoneNumber}</td>
          </tr>
        ))}
      </Table>
      {userDetail && showDetail && (
        <Info user={userDetail} handleClose={handleCloseDetail} />
      )}
    </>
  );
};

export default UserTable;
