import { useEffect, useState } from "react";

interface FigmaPageProps {
  children: React.ReactNode;
  height: number;
}

export function FigmaPage({ children, height }: FigmaPageProps) {
  const [scale, setScale] = useState(() => {
    if (typeof window !== "undefined") {
      return window.innerWidth < 1920 ? window.innerWidth / 1920 : 1;
    }
    return 1;
  });

  useEffect(() => {
    const handleResize = () => {
      const windowWidth = window.innerWidth;
      // We scale down if window is smaller than 1920px
      if (windowWidth < 1920) {
        setScale(windowWidth / 1920);
      } else {
        setScale(1);
      }
    };
    
    handleResize();
    window.addEventListener("resize", handleResize);
    return () => window.removeEventListener("resize", handleResize);
  }, []);

  return (
    <div className="w-full bg-[#f4f4f4] overflow-x-hidden flex justify-center">
      <div 
        className="relative origin-top bg-white shadow-xl"
        style={{ 
          width: '1920px', 
          height: `${height}px`,
          transform: `scale(${scale})`,
          marginBottom: `-${height * (1 - scale)}px`
        }}
      >
        {children}
      </div>
    </div>
  );
}
