import { useNavigate } from "react-router";
import DetailComponent from "../../imports/Detail/Detail";

export default function DetailPage() {
  const navigate = useNavigate();

  const handleNavigation = (e: React.MouseEvent) => {
    const target = e.target as HTMLElement;
    const text = target.textContent?.trim().toLowerCase();

    if (text === "home") navigate("/");
    else if (text === "our story") navigate("/our-story");
    else if (text === "shop" || text === "product") navigate("/shop");
    else if (text === "cart") navigate("/cart");
    else if (text === "feedback") navigate("/feedback");
    else if (text === "detail" || text === "product detail") navigate("/detail/1");
  };

  return (
    <div className="w-full h-[1200px] relative" onClick={handleNavigation}>
      <DetailComponent />
    </div>
  );
}