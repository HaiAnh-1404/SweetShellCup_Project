import { createBrowserRouter } from "react-router";
import { AppLayout } from "./components/AppLayout";
import HomePage from "./pages/HomePage";
import OurStoryPage from "./pages/OurStoryPage";
import ShopPage from "./pages/ShopPage";
import CartPage from "./pages/CartPage";
import FeedbackPage from "./pages/FeedbackPage";
import DetailPage from "./pages/DetailPage";

export const router = createBrowserRouter([
  {
    path: "/",
    Component: AppLayout,
    children: [
      {
        index: true,
        Component: HomePage,
      },
      {
        path: "our-story",
        Component: OurStoryPage,
      },
      {
        path: "shop",
        Component: ShopPage,
      },
      {
        path: "cart",
        Component: CartPage,
      },
      {
        path: "feedback",
        Component: FeedbackPage,
      },
      {
        path: "detail/:id",
        Component: DetailPage,
      },
    ]
  }
]);