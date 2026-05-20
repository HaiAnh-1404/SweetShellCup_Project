import { useNavigate } from "react-router";
import OurStoryComponent from "../../imports/OurStory/OurStory";

export default function OurStoryPage() {
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
    <div className="w-full h-[6000px] relative" onClick={handleNavigation}>
      <OurStoryComponent />
    </div>
  );
}