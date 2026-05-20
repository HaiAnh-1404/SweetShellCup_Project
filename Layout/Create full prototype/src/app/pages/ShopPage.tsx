import { useNavigate } from "react-router";
import ProductComponent from "../../imports/Product/Product";

export default function ShopPage() {
  const navigate = useNavigate();

  const handleNavigation = (e: React.MouseEvent) => {
    const target = e.target as HTMLElement;
    const text = target.textContent?.trim().toLowerCase();

    if (text === "home") navigate("/");
    else if (text === "our story") navigate("/our-story");
    else if (text === "shop" || text === "product") navigate("/shop");
    else if (text === "cart") navigate("/cart");
    else if (text === "feedback") navigate("/feedback");
    else if (text === "detail" || text === "product detail" || text === "shop now" || text === "buy now") navigate("/detail/1");
  };

  return (
    <div className="w-full h-[4300px] relative" onClick={handleNavigation}>
      <ProductComponent />
    </div>
  );
}