import { styled } from "@mui/material";
import React from "react";

const StyledFooter = styled("footer")({
  bottom: 0,
  left: 0,
  right: 0,
  background: "#0099CC",
  height: "auto",
  width: "100%",
  color: "#fff",
  marginTop: "20px",
  position: "static",
});

const FooterContent = styled("div")({
  display: "flex",
  alignItems: "center",
  justifyContent: "center",
  flexDirection: "column",
  textAlign: "center",
});

const FooterContentH3 = styled("h3")({
  fontSize: "1.8rem",
  fontWeight: 400,
  textTransform: "capitalize",
  lineHeight: "3rem",
  color: "white",
});

const FooterContentP = styled("p")({
  maxWidth: "500px",
  margin: "10px auto",
  lineHeight: "28px",
  fontSize: "14px",
  color: "white",
});

const FooterBottom = styled("div")({
  background: "#0099CC",
  width: "100%",
  padding: "20px 0",
  textAlign: "center",
});
const FooterBottomP = styled("p")({
  fontSize: "14px",
  wordSpacing: "2px",
  textTransform: "capitalize",
  color: "white",
});

const Footer = () => {
  return (
    <>
      <StyledFooter>
        <FooterContent>
          <FooterContentH3>uniWebShop</FooterContentH3>
          <FooterContentP>The trusted webshop of all kinds.</FooterContentP>
        </FooterContent>
        <FooterBottom>
          <FooterBottomP>
            Copyright &copy; {new Date().getFullYear()} Krumplik team.
          </FooterBottomP>
        </FooterBottom>
      </StyledFooter>
    </>
  );
};

export default Footer;
