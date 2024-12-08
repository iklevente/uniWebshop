import React, { useState, useCallback, useEffect, useContext } from "react";
import { styled, Grid } from "@mui/material";
import {
  ProductContext,
  ProductContextProvider,
} from "../../context-providers/ProductContext";
import Filter from "./Filter";
import CardWithProps from "../main-page/best-deals/Card";

const StyledPadding = styled("div")({
  backgroundColor: "#00CCFF",
  paddingLeft: "25px",
  paddingRight: "25px",
  paddingBottom: "50px",
});

const StyledDiv = styled("div")({
  backgroundColor: "#00CCFF",
});

const StyledContent = styled("div")({
  display: "flex",
  alignItems: "start",
  justifyContent: "center",
  height: "100%",
});

const StyledProductDiv = styled("div")({
  width: "70%",
  "@keyframes pagestartanimation": {
    from: {
      opacity: "0%",
    },
    "50%": {
      opacity: "0%",
    },
    to: {
      opacity: "100%",
    },
  },
  animation: "pagestartanimation 1.5s 1 ease",
  position: "static",
});

var INITIAL_MIN_PRICE_VALUE = 0;
var INITIAL_MAX_PRICE_VALUE = 9999;

const SearchPageInside = () => {
  const { products } = useContext(ProductContext);
  const [filteredProducts, setFilteredProducts] = useState(products);
  const [searchString, setSearchString] = useState("");
  const [selectedTags, setSelectedTags] = useState([]);
  const [selectedPriceRange, setSelectedPriceRange] = useState([
    INITIAL_MIN_PRICE_VALUE,
    INITIAL_MAX_PRICE_VALUE,
  ]);

  // NEW CODE SNIPPET
  useEffect(() => {
    const priceRangeOfProducts = () => {
      let minPrice = 0;
      let maxPrice = minPrice;
      for (let i = 0; i < products.length; i++) {
        if (minPrice > products[i].price) {
          minPrice = products[i].price;
        }
        if (maxPrice < products[i].price) {
          maxPrice = products[i].price;
        }
      }
      return [minPrice, maxPrice];
    };

    if (products.length > 0) {
      const priceRange = priceRangeOfProducts();
      setSelectedPriceRange([priceRange[0], priceRange[1]]);
    }
  }, [products]);

  const [sortBy, setSortBy] = useState(""); // Possible values: "name", "price"
  const [descending, setDescending] = useState(false);

  const filterProducts = useCallback(() => {
    let filtered = [...products];

    if (searchString.length > 0) {
      filtered = filtered.filter((product) => {
        return product.title.toLowerCase().includes(searchString.toLowerCase());
      });
    }

    if (selectedTags.length > 0) {
      filtered = filtered.filter((product) => {
        return selectedTags.every((tags) => product.tags.includes(tags));
      });
    }

    if (selectedPriceRange.length > 0) {
      filtered = filtered.filter((product) => {
        return (
          product.price <= selectedPriceRange[1] &&
          product.price >= selectedPriceRange[0]
        );
      });
    }

    // Sorting
    if (sortBy === "name") {
      filtered.sort((a, b) =>
        descending
          ? b.title.localeCompare(a.title)
          : a.title.localeCompare(b.title)
      );
    } else if (sortBy === "price") {
      filtered.sort((a, b) =>
        descending ? b.price - a.price : a.price - b.price
      );
    }

    setFilteredProducts(filtered);
  }, [
    selectedTags,
    searchString,
    selectedPriceRange,
    products,
    sortBy,
    descending,
  ]);

  useEffect(() => {
    filterProducts();
  }, [filterProducts]);

  const handleSearch = (e) => {
    setSearchString(e.target.value);
  };

  return (
    <>
      <StyledPadding>
        <StyledDiv>
          <StyledContent>
            <Filter
              handleSearch={handleSearch}
              selectedTags={selectedTags}
              setSelectedTags={setSelectedTags}
              selectedPriceRange={selectedPriceRange}
              setSelectedPriceRange={setSelectedPriceRange}
              filterProducts={filterProducts}
              INITIAL_MIN_PRICE_VALUE={INITIAL_MIN_PRICE_VALUE}
              INITIAL_MAX_PRICE_VALUE={INITIAL_MAX_PRICE_VALUE}
              sortBy={sortBy}
              setSortBy={setSortBy}
              descending={descending}
              setDescending={setDescending}
            />
            <StyledProductDiv>
              <Grid
                container
                spacing={10}
                justifyContent="center"
                marginTop={1}
                marginBottom={5}
                paddingBottom={5}
              >
                {filteredProducts.length === 0 ? (
                  <div>No product satisfies your filters</div>
                ) : (
                  filteredProducts.map((product) => (
                    <Grid item xs="auto" md="auto" key={product.id}>
                      <CardWithProps id={product.id} />
                    </Grid>
                  ))
                )}
              </Grid>
            </StyledProductDiv>
          </StyledContent>
        </StyledDiv>
      </StyledPadding>
    </>
  );
};

const SearchPage = () => {
  return (
    <>
      <ProductContextProvider>
        <SearchPageInside />
      </ProductContextProvider>
    </>
  );
};

export default SearchPage;
