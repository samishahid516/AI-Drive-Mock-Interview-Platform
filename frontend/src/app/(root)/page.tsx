import AuthForm from "@/frontend/components/auth/AuthForm";

// Root "/" shows Sign Up page directly
export default function Home() {
  return <AuthForm type="sign-up" />;
}
